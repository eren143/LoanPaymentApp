public class OdemePlani
{
    public int Id { get; set; }
    public int OdemeSayisi { get; set; }
    public List<OdemeSatiri> Satirlar { get; set; } = new List<OdemeSatiri>();
}

public class OdemeSatiri
{
    public int Id { get; set; }
    public int TaksitNo { get; set; }
    public double Taksit { get; set; }
    public double Anapara { get; set; }
    public double Faiz { get; set; }
    public double KalanTutar { get; set; }
    public int OdemePlaniId { get; set; } // Foreign key
    public OdemePlani OdemePlani { get; set; } // Navigation property
}