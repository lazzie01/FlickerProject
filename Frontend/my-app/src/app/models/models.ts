export class User {
    id: number;
    testCentreId : number;
    roleId:number;
    username: string;
    password: string;
    name: string;
    surname: string;
    organization:string;
    department :string;
    phone: string;
    email: string;
    activated:boolean;
    token: string;
    testCentre?:any;
    role:any;
}

export class Enum {
    key: number;
    value: string;
}

//below is junk
export class Location {
    id: number;
    name: string;
}

export class Search {
    id: number;
    query: string;
}

export class Landmark {
    id: number;
    locationId : number;
    fLargeUrl : string;
    fThumbnailUrl  : string;
    title  : string;
    description  : string;
    largeUrl  : string;
    thumbnailUrl  : string;
    dateUploaded   : any;
}