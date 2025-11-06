namespace Solution.Services;

public class BillService(AppDbContext dbContext) : IBillService
{
    private const int ROW_COUNT = 20;

    public async Task<ErrorOr<BillModel>> CreateAsync(BillModel model)
    {
        // Set current date if not provided
        if (!model.BillDate.HasValue)
        {
            model.BillDate = DateTime.Now;
        }

        // Check if bill with same number already exists
        bool exists = await dbContext.Bills.AnyAsync(x => x.BillNumber.ToLower() == model.BillNumber.ToLower().Trim());

        if (exists)
        {
            return Error.Conflict(description: "Bill with this number already exists!");
        }

        var bill = model.ToEntity();

        await dbContext.Bills.AddAsync(bill);
        await dbContext.SaveChangesAsync();

        return new BillModel(bill);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(BillModel model)
    {
        var existingBill = await dbContext.Bills
            .Include(b => b.Items)
            .FirstOrDefaultAsync(x => x.Id == model.Id);

        if (existingBill == null)
        {
            return Error.NotFound(description: "Bill not found.");
        }

        // Set current date if not provided
        if (!model.BillDate.HasValue)
        {
            model.BillDate = DateTime.Now;
        }

        // Update bill properties only if provided
        if (!string.IsNullOrWhiteSpace(model.BillNumber))
        {
            existingBill.BillNumber = model.BillNumber;
        }
        existingBill.BillDate = model.BillDate.Value;

        // Remove items that are no longer in the model
        var itemsToRemove = existingBill.Items
            .Where(ei => !model.Items.Any(mi => mi.Id == ei.Id))
            .ToList();

        foreach (BillItemEntity? item in itemsToRemove)
        {
            dbContext.BillItems.Remove(item);
        }

        // Update or add items
        foreach (var modelItem in model.Items)
        {
            var existingItem = existingBill.Items.FirstOrDefault(i => i.Id == modelItem.Id);
            
            if (existingItem != null)
            {
                // Update existing item
                existingItem.ItemName = modelItem.ItemName;
                existingItem.Quantity = modelItem.Quantity.Value;
                existingItem.UnitPrice = modelItem.UnitPrice.Value;
            }
            else
            {
                // Add new item
                var newItem = modelItem.ToEntity();
                newItem.BillId = existingBill.Id;
                existingBill.Items.Add(newItem);
            }
        }

        await dbContext.SaveChangesAsync();
        return Result.Success;
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int billId)
    {
        var result = await dbContext.Bills
            .Where(x => x.Id == billId)
            .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<BillModel>> GetByIdAsync(int billId)
    {
        var bill = await dbContext.Bills
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == billId);

        return bill is null ? (ErrorOr<BillModel>)Error.NotFound(description: "Bill not found.") : (ErrorOr<BillModel>)new BillModel(bill);
    }

    public async Task<ErrorOr<List<BillModel>>> GetAllAsync() =>
        await dbContext.Bills
            .AsNoTracking()
            .Include(x => x.Items)
            .Select(x => new BillModel(x))
            .ToListAsync();

    public async Task<ErrorOr<PaginationModel<BillModel>>> GetPagedAsync(int page = 1)
    {
        page = page < 1 ? 1 : page - 1;

        var totalCount = await dbContext.Bills.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / ROW_COUNT);

        var bills = await dbContext.Bills
            .AsNoTracking()
            .Include(x => x.Items)
            .OrderByDescending(x => x.BillDate)
            .Skip(page * ROW_COUNT)
            .Take(ROW_COUNT)
            .Select(x => new BillModel(x))
            .ToListAsync();

        var paginationModel = new PaginationModel<BillModel>
        {
            Items = bills,
            Count = totalCount,
            TotalPages = totalPages
        };

        return paginationModel;
    }
}
