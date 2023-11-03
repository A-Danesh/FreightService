// See https://aka.ms/new-console-template for more information

namespace FreightService
{
    public interface IAirport
    {
        string Code { get; }
        string Name { get; }
    }
}