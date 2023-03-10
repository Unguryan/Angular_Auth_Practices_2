import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appPhoneDer]'
})
export class PhoneDerDirective {

  constructor(private element: ElementRef, private render: Renderer2) { }

  @HostListener('keydown', ['$event']) ClickEvent(event: KeyboardEvent){
    if(event.key == "Backspace"){

      var value = this.element.nativeElement.value as string;

      if((value.length == 4 || value.length == 8) && value[value.length - 1] == "-"){
        this.render.setProperty(this.element.nativeElement, 'value', value.substring(0, value.length - 1));
      }
    }
  }

}
