// See https://aka.ms/new-console-template for more information

namespace FreightService.Repository
{
    public class Airport
    {
        private string Code { get; set; }
        private string Name { get; set; }
        public Airport(string code,string name)
        {
            Code = code;
            Name = name;
        }
    }
}