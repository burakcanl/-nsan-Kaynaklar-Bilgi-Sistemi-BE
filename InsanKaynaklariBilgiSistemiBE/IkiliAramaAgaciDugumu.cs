using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemiBE
{
    public class IkiliAramaAgaciDugumu
    {

            public Kisi veri;
            public IkiliAramaAgaciDugumu sol;
            public IkiliAramaAgaciDugumu sag;
            public IkiliAramaAgaciDugumu()
            {
            }

            public IkiliAramaAgaciDugumu(Kisi veri)
            {
                this.veri = veri;
                sol = null;
                sag = null;
            }
        }
}
