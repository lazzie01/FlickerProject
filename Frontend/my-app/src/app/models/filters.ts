import { PipeTransform, Pipe } from '@angular/core';
@Pipe({
    name: 'searchFilter'
})
export class SearchFilterPipe implements PipeTransform{

    transform(contacts:any[], searchTerm:string): any[]{
        if(!contacts || !searchTerm){
            return contacts;
        }
       return contacts.filter(contact=>
        contact.name.toLowerCase()
                          .indexOf(searchTerm.toLowerCase())!== -1)
    }
}