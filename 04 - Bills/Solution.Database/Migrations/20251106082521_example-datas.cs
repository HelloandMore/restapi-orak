using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solution.Database.Migrations
{
    /// <inheritdoc />
    public partial class exampledatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert Bills
            migrationBuilder.InsertData(
                table: "Bill",
                columns: new[] { "BillNumber", "BillDate" },
                values: new object[,]
                {
                    { "INV-2024-001", new DateTime(2024, 1, 15, 10, 30, 0) },
                    { "INV-2024-002", new DateTime(2024, 1, 20, 14, 45, 0) },
                    { "INV-2024-003", new DateTime(2024, 2, 5, 9, 15, 0) },
                    { "INV-2024-004", new DateTime(2024, 2, 12, 16, 20, 0) },
                    { "INV-2024-005", new DateTime(2024, 3, 8, 11, 0, 0) },
                    { "INV-2024-006", new DateTime(2024, 3, 22, 13, 30, 0) },
                    { "INV-2024-007", new DateTime(2024, 4, 3, 10, 45, 0) },
                    { "INV-2024-008", new DateTime(2024, 4, 18, 15, 10, 0) },
                    { "INV-2024-009", new DateTime(2024, 5, 7, 12, 25, 0) },
                    { "INV-2024-010", new DateTime(2024, 5, 25, 14, 0, 0) },
                    { "INV-2024-011", new DateTime(2024, 6, 10, 9, 30, 0) },
                    { "INV-2024-012", new DateTime(2024, 6, 28, 16, 45, 0) },
                    { "INV-2024-013", new DateTime(2024, 7, 14, 11, 20, 0) },
                    { "INV-2024-014", new DateTime(2024, 7, 30, 13, 15, 0) },
                    { "INV-2024-015", new DateTime(2024, 8, 5, 10, 0, 0) },
                    { "INV-2024-016", new DateTime(2024, 8, 20, 15, 30, 0) },
                    { "INV-2024-017", new DateTime(2024, 9, 9, 12, 45, 0) },
                    { "INV-2024-018", new DateTime(2024, 9, 25, 14, 20, 0) },
                    { "INV-2024-019", new DateTime(2024, 10, 12, 9, 50, 0) },
                    { "INV-2024-020", new DateTime(2024, 10, 28, 16, 15, 0) }
                });

            // Insert Bill Items for Bill 1 - Electronics Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Laptop Dell XPS 15", 1, 489990.00m, 1 },
                    { "Wireless Mouse Logitech MX Master", 1, 37990.00m, 1 },
                    { "USB-C Hub 7-in-1", 2, 18990.00m, 1 },
                    { "Laptop Sleeve 15 inch", 1, 11490.00m, 1 }
                });

            // Insert Bill Items for Bill 2 - Restaurant
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Grilled Salmon with Vegetables", 2, 4990.00m, 2 },
                    { "Caesar Salad", 2, 2590.00m, 2 },
                    { "Margherita Pizza", 1, 3190.00m, 2 },
                    { "Tiramisu", 2, 1790.00m, 2 },
                    { "Espresso", 3, 690.00m, 2 },
                    { "Glass of Red Wine", 2, 1990.00m, 2 }
                });

            // Insert Bill Items for Bill 3 - Office Supplies
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "A4 Paper Ream (500 sheets)", 10, 2290.00m, 3 },
                    { "Blue Ballpoint Pens (Pack of 50)", 5, 4990.00m, 3 },
                    { "Stapler Heavy Duty", 3, 5990.00m, 3 },
                    { "File Folders (Pack of 25)", 4, 3490.00m, 3 },
                    { "Whiteboard Markers Set", 6, 3790.00m, 3 },
                    { "Desk Organizer", 2, 7590.00m, 3 }
                });

            // Insert Bill Items for Bill 4 - Clothing Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Men's Cotton T-Shirt Navy Blue", 3, 7590.00m, 4 },
                    { "Women's Jeans Slim Fit", 2, 18990.00m, 4 },
                    { "Leather Belt Brown", 1, 13290.00m, 4 },
                    { "Sport Socks (3-Pack)", 2, 4990.00m, 4 }
                });

            // Insert Bill Items for Bill 5 - Hardware Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Cordless Drill 20V", 1, 56990.00m, 5 },
                    { "Drill Bit Set (50 pieces)", 1, 15190.00m, 5 },
                    { "Hammer Claw 16oz", 2, 7590.00m, 5 },
                    { "Screwdriver Set (12 pieces)", 1, 9490.00m, 5 },
                    { "Measuring Tape 25ft", 3, 3790.00m, 5 },
                    { "Work Gloves (Pair)", 5, 3090.00m, 5 }
                });

            // Insert Bill Items for Bill 6 - Grocery Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Organic Milk 1 Gallon", 2, 2290.00m, 6 },
                    { "Whole Wheat Bread", 3, 1290.00m, 6 },
                    { "Fresh Eggs (Dozen)", 2, 1890.00m, 6 },
                    { "Chicken Breast 2lbs", 1, 4990.00m, 6 },
                    { "Mixed Vegetables Frozen", 4, 1190.00m, 6 },
                    { "Orange Juice 64oz", 2, 1690.00m, 6 },
                    { "Pasta Penne 1lb", 5, 790.00m, 6 },
                    { "Tomato Sauce 24oz", 3, 990.00m, 6 }
                });

            // Insert Bill Items for Bill 7 - Bookstore
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "The Pragmatic Programmer (Book)", 1, 16290.00m, 7 },
                    { "Clean Code by Robert Martin", 1, 14790.00m, 7 },
                    { "Design Patterns: Elements of Reusable", 1, 20890.00m, 7 },
                    { "Moleskine Notebook Classic", 2, 6490.00m, 7 },
                    { "Bookmark Set (5 pieces)", 1, 3490.00m, 7 }
                });

            // Insert Bill Items for Bill 8 - Coffee Shop
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Caffe Latte Grande", 4, 1290.00m, 8 },
                    { "Cappuccino Regular", 2, 1090.00m, 8 },
                    { "Croissant", 3, 890.00m, 8 },
                    { "Blueberry Muffin", 2, 790.00m, 8 },
                    { "Chocolate Chip Cookie", 5, 590.00m, 8 },
                    { "Bottled Water", 3, 490.00m, 8 }
                });

            // Insert Bill Items for Bill 9 - Furniture Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Office Chair Ergonomic", 2, 94990.00m, 9 },
                    { "Standing Desk Adjustable", 1, 151990.00m, 9 },
                    { "Bookshelf 5-Tier", 1, 49390.00m, 9 },
                    { "LED Desk Lamp", 2, 15190.00m, 9 }
                });

            // Insert Bill Items for Bill 10 - Pharmacy
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Vitamin C 1000mg (100 tablets)", 2, 4990.00m, 10 },
                    { "Multivitamin Daily (60 tablets)", 1, 7590.00m, 10 },
                    { "Pain Relief Ibuprofen 200mg", 1, 3490.00m, 10 },
                    { "First Aid Kit", 1, 9490.00m, 10 },
                    { "Digital Thermometer", 1, 5690.00m, 10 },
                    { "Hand Sanitizer 8oz", 3, 1890.00m, 10 }
                });

            // Insert Bill Items for Bill 11 - Pet Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Dog Food Premium 30lbs", 1, 20890.00m, 11 },
                    { "Cat Litter 20lbs", 2, 7190.00m, 11 },
                    { "Dog Toy Rope Large", 3, 3790.00m, 11 },
                    { "Cat Scratching Post", 1, 13290.00m, 11 },
                    { "Pet Shampoo Gentle Formula", 2, 4990.00m, 11 }
                });

            // Insert Bill Items for Bill 12 - Sporting Goods
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Yoga Mat Premium 6mm", 2, 11390.00m, 12 },
                    { "Dumbbells Set 20lbs Pair", 1, 34190.00m, 12 },
                    { "Resistance Bands Set (5 bands)", 1, 9490.00m, 12 },
                    { "Running Shoes Men's Size 10", 1, 45590.00m, 12 },
                    { "Sports Water Bottle 32oz", 3, 5690.00m, 12 },
                    { "Gym Bag Large", 1, 15190.00m, 12 }
                });

            // Insert Bill Items for Bill 13 - Garden Center
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Potting Soil 40lbs", 3, 4990.00m, 13 },
                    { "Garden Hose 50ft", 1, 13290.00m, 13 },
                    { "Tomato Plant Seedlings (6-pack)", 2, 3490.00m, 13 },
                    { "Garden Gloves Heavy Duty", 2, 3790.00m, 13 },
                    { "Watering Can 2 Gallon", 1, 6490.00m, 13 },
                    { "Plant Fertilizer All-Purpose 5lbs", 2, 5690.00m, 13 }
                });

            // Insert Bill Items for Bill 14 - Toy Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "LEGO City Police Station Set", 1, 30390.00m, 14 },
                    { "Board Game Monopoly Classic", 1, 9490.00m, 14 },
                    { "Puzzle 1000 Pieces Landscape", 2, 7590.00m, 14 },
                    { "Action Figure Superhero", 3, 5690.00m, 14 },
                    { "Stuffed Animal Teddy Bear", 2, 7190.00m, 14 }
                });

            // Insert Bill Items for Bill 15 - Auto Parts Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Motor Oil Synthetic 5W-30 (5 Quart)", 2, 12550.00m, 15 },
                    { "Oil Filter Premium", 2, 4990.00m, 15 },
                    { "Air Filter Cabin", 1, 7190.00m, 15 },
                    { "Windshield Wipers Set (2)", 1, 9490.00m, 15 },
                    { "Car Wash Soap 64oz", 1, 3790.00m, 15 },
                    { "Microfiber Towels (Pack of 6)", 1, 5690.00m, 15 }
                });

            // Insert Bill Items for Bill 16 - Beauty Supply
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Shampoo Professional 16oz", 2, 7190.00m, 16 },
                    { "Conditioner Moisturizing 16oz", 2, 7590.00m, 16 },
                    { "Hair Dryer Ionic 1875W", 1, 18990.00m, 16 },
                    { "Nail Polish Set (12 colors)", 1, 9490.00m, 16 },
                    { "Makeup Brush Set (15 pieces)", 1, 15190.00m, 16 },
                    { "Face Cream Anti-Aging 2oz", 1, 13290.00m, 16 }
                });

            // Insert Bill Items for Bill 17 - Music Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Acoustic Guitar Beginner Pack", 1, 75990.00m, 17 },
                    { "Guitar Strings Set (6 sets)", 3, 3490.00m, 17 },
                    { "Music Stand Folding", 1, 9490.00m, 17 },
                    { "Guitar Picks (Pack of 12)", 2, 2290.00m, 17 },
                    { "Guitar Tuner Digital", 1, 7590.00m, 17 }
                });

            // Insert Bill Items for Bill 18 - Bakery
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Sourdough Bread Loaf", 2, 1490.00m, 18 },
                    { "Croissants (Pack of 6)", 1, 2990.00m, 18 },
                    { "Chocolate Cake 8 inch", 1, 6990.00m, 18 },
                    { "Cinnamon Rolls (Pack of 4)", 2, 2490.00m, 18 },
                    { "Bagels Mixed Dozen", 1, 3990.00m, 18 },
                    { "Apple Pie Slice", 4, 890.00m, 18 }
                });

            // Insert Bill Items for Bill 19 - Art Supply Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Acrylic Paint Set (24 colors)", 1, 13290.00m, 19 },
                    { "Canvas Panels 16x20 (Pack of 6)", 2, 11390.00m, 19 },
                    { "Paintbrush Set (15 pieces)", 1, 9490.00m, 19 },
                    { "Sketch Pad 9x12 (100 sheets)", 2, 4990.00m, 19 },
                    { "Colored Pencils (Set of 48)", 1, 8730.00m, 19 },
                    { "Artist Easel Tabletop", 1, 15190.00m, 19 }
                });

            // Insert Bill Items for Bill 20 - Computer Store
            migrationBuilder.InsertData(
                table: "BillItem",
                columns: new[] { "ItemName", "Quantity", "UnitPrice", "BillId" },
                values: new object[,]
                {
                    { "Gaming Monitor 27 inch 144Hz", 1, 132990.00m, 20 },
                    { "Mechanical Keyboard RGB", 1, 49390.00m, 20 },
                    { "Gaming Mouse Wireless", 1, 30390.00m, 20 },
                    { "Mousepad Extended XXL", 1, 9490.00m, 20 },
                    { "USB Webcam 1080p", 1, 26590.00m, 20 },
                    { "Headset Gaming 7.1 Surround", 1, 34190.00m, 20 },
                    { "HDMI Cable 6ft (Pack of 2)", 1, 5690.00m, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Delete all bill items first (due to foreign key constraint)
            migrationBuilder.DeleteData(
                table: "BillItem",
                keyColumn: "BillId",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            // Delete all bills
            migrationBuilder.DeleteData(
                table: "Bill",
                keyColumn: "BillNumber",
                keyValues: new object[] 
                { 
                    "INV-2024-001", "INV-2024-002", "INV-2024-003", "INV-2024-004", "INV-2024-005",
                    "INV-2024-006", "INV-2024-007", "INV-2024-008", "INV-2024-009", "INV-2024-010",
                    "INV-2024-011", "INV-2024-012", "INV-2024-013", "INV-2024-014", "INV-2024-015",
                    "INV-2024-016", "INV-2024-017", "INV-2024-018", "INV-2024-019", "INV-2024-020"
                });
        }
    }
}
