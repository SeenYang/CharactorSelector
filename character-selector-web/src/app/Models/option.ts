
export interface Option{
  id: string;
  parentOptionId: string;
  characterId: string;
  type: string;
  name: string;
  description: string;
  imgUrl: string;
  subOptions: Option[];
}
