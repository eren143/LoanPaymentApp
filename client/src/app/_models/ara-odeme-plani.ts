export interface AraOdemePlani {
    id: number;
    odemeSayisi: number;
    satirlar: AraOdemeSatiri[];
  }
  
  export interface AraOdemeSatiri {
    id: number;
    taksitNo: number;
    taksit: number;
    anapara: number;
    faiz: number;
    kalanTutar: number;
  }