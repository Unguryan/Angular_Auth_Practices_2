export class RegisterViewModel {

    constructor(public name: string,
        public surname: string,
        public email: string,
        public phone: string,
        public password: string) {
    }
}

export class RegisterResultViewModel {

    constructor(public isSuccess: boolean,
        public token: string,
        public errorMessage?: string) {
    }
}

export class LoginViewModel {

    constructor(public password: string,
        public phone?: string,
        public email?: string) {
    }
}

export class LoginResultViewModel {

    constructor(public isSuccess: boolean,
        public token: string,
        public errorMessage?: string) {
    }
}

export class LogoutViewModel {

    constructor(public token: string) {
    }
}

export class LogoutResultViewModel {

    constructor(public isSuccess: boolean,
        public errorMessage?: string) {
    }
}

export class TokenDataModel {
    public token: string;
    public name: string;
    public surname: string;
    public email: string;
    public phone: string;
    public expired: Date;
    
}

