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

    public static object ErrorBadRequest()
    {
        return new
        {
            error = new
            {
                statusCode = 400,
                message = "Bad Request",
                error = "Some fields are empty"
            }
        };
    }

    public static object ErrorInternalServerError()
    {
        return new
        {
            error = new
            {
                statusCode = 500,
                message = "Internal Server Error",
                error = "An error occurred"
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
}