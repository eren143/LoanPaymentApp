using System;
using API.Entities;

namespace API.Services
{
    public class AraOdemeService
    {
        public OdemePlani AraOdemePlaniOlustur(double krediTutari, int vade, double faiz, int ilkAraOdemeTaksitNo, int araOdemeSikliği, double araOdemeTutari)
        {

            var araOdemeSayisi = (vade-ilkAraOdemeTaksitNo)/araOdemeSikliği+1;
            Console.WriteLine($"Ara odeme sayisi: {araOdemeSayisi}");

            faiz = faiz/100;
            var araOdemeFaizi = Math.Pow(1+faiz,araOdemeSikliği)-1;

            var PVaraOdemeIlkOdeme = araOdemeTutari + araOdemeTutari*(Math.Pow(1+araOdemeFaizi,araOdemeSayisi-1)-1)/(araOdemeFaizi*Math.Pow(1+araOdemeFaizi,araOdemeSayisi-1));

            var PVaraOdeme = PVaraOdemeIlkOdeme*Math.Pow(faiz+1,-ilkAraOdemeTaksitNo);

            var araOdemesizAnapara = krediTutari - PVaraOdeme;

            var taksit = araOdemesizAnapara*(faiz*Math.Pow(1+faiz,vade))/(Math.Pow(1+faiz,vade)-1);

            Console.WriteLine($"TAKSit: {taksit}");

            var odemePlani = new OdemePlani();
            odemePlani.OdemeSayisi = vade;

            var kalanPara = krediTutari;

            for(int i = 1; i<=vade;i++){

                var faizOdemesi = kalanPara*faiz;
                var taksitOdemesi = taksit;
                if(i>= ilkAraOdemeTaksitNo &&
                    (i-ilkAraOdemeTaksitNo)%araOdemeSikliği==0){
                    taksitOdemesi = taksitOdemesi+araOdemeTutari;
                }   
                var anaparaOdemesi = taksitOdemesi-faizOdemesi;
                kalanPara = kalanPara-anaparaOdemesi;
                odemePlani.Satirlar.Add(new OdemeSatiri
                {
                    Faiz = faizOdemesi,
                    Taksit = taksitOdemesi,
                    TaksitNo = i,
                    Anapara = anaparaOdemesi,
                    KalanTutar = kalanPara
                });
            }
            return odemePlani;
        }

    }
}
/*
*/


/*
                    Taksit = monthlyInstallment,
                    TaksitNo = i,
                    Anapara = principalPayment,
                    KalanTutar = remainingBalance - principalPayment
                odemePlani.Satirlar.Add(new AraOdemeSatiri
                {
                    Faiz = interestPayment,
*/
                