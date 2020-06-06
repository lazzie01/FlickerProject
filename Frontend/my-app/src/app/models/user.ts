export class User {
    id: number;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
    token: string;
}

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