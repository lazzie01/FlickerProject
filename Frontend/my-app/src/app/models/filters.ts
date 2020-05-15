import { PipeTransform, Pipe } from '@angular/core';
import { DomSanitizer, SafeHtml, SafeStyle, SafeScript, SafeUrl, SafeResourceUrl } from '@angular/platform-browser';

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

@Pipe({
    name: 'safe'
  })
  export class SafePipe implements PipeTransform {
  
    constructor(protected sanitizer: DomSanitizer) {}
  
   public transform(value: any, type: string): SafeHtml | SafeStyle | SafeScript | SafeUrl | SafeResourceUrl {
      switch (type) {
              case 'html': return this.sanitizer.bypassSecurityTrustHtml(value);
              case 'style': return this.sanitizer.bypassSecurityTrustStyle(value);
              case 'script': return this.sanitizer.bypassSecurityTrustScript(value);
              case 'url': return this.sanitizer.bypassSecurityTrustUrl(value);
              case 'resourceUrl': return this.sanitizer.bypassSecurityTrustResourceUrl(value);
              default: throw new Error(`Invalid safe type specified: ${type}`);
          }
    }
  }