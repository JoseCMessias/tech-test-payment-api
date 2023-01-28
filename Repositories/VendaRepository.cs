using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly VendaContext _context;

        public VendaRepository(VendaContext context)
        {
            _context = context;
        }
        public Venda BuscarVenda(int id)
        {
            return _context.Dbvendas.Where(e => e.IdVenda == id).FirstOrDefault();
        }
        public void Create(Venda venda)
        {
            _context.Dbvendas.Add(venda);
            _context.SaveChanges();
        }
        public void Update(Venda vendaAtual, Venda venda)
        {
            _context.Dbvendas.Update(vendaAtual).CurrentValues.SetValues(venda);
            _context.SaveChanges();
        }
    }
}
