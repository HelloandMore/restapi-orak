namespace Solution.Validators;

public abstract class BaseValidator<T>(IHttpContextAccessor httpContextAccessor) : AbstractValidator<T> where T: class
{
    private string RequestedMethod => httpContextAccessor?.HttpContext?.Request.Method;

    protected bool IsPutMethod => RequestedMethod is not null && HttpMethods.IsPut(RequestedMethod);

}
