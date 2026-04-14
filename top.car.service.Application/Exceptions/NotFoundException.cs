namespace top.car.service.Application.Exceptions;
public sealed class NotFoundException(string Messages) : Exception(Messages)
{

}