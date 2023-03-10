import { AbstractControl, ValidationErrors, Validator } from "@angular/forms";

    export function phoneValidator(control: AbstractControl<any, any>): ValidationErrors | null 
    {
        var value = control.value as string;

        var pattern = /\d{3}[-]\d{3}[-]\d{4}/;

        if(value != null && pattern.test(value)){
            return null;
        }

        if(value.length == 3 || value.length == 7){
            control.patchValue(value + "-",
                {emitEvent: false }
            );
        }

        return {
            phone: true
        };
    }