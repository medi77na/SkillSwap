namespace SkillSwap.Models;
public static class ManageResponse
{
    public static object ErrorUnauthorized()
    {
        return new
        {
            error = new
            {
                statusCode = 401,
                message = "Authentication required",
                error = "Unauthorized"
            }
        };
    }

    public static object ErrorBadRequest(string text)
    {
        return new
        {
            error = new
            {
                statusCode = 400,
                message = "Bad Request",
                error = text
            }
        };
    }

    public static object ErrorInternalServerError(string text)
    {
        return new
        {
            error = new
            {
                statusCode = 500,
                message = text,
                error = "Internal Server Error"
            }
        };
    }

    public static object ErrorNotFound()
    {
        return new
        {
            error = new
            {
                statusCode = 404,
                message = "Not Found",
                error = "The requested resource was not found"
            }
        };
    }

    public static object Successfull(string text)
    {
        return new
        {
            message = "Success",
            details = new
            {
                text
            }
        };
    }

    public static object SuccessfullWithObject(string text, object response)
    {
        return new
        {
            message = "Success",
            details = new
            {
                text
            },
            data = new
            {
                response
            }
        };
    }
}