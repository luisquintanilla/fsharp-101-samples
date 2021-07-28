type Address = {HouseNumber:int; StreetName: string}
type PhoneNumber = {Code:int; Number:string}

type ContactMethod = 
    | PostalMail of Address
    | Email of string
    | VoiceMail of PhoneNumber
    | SMS of PhoneNumber

let sendMessage (message:string) (contactMethod:ContactMethod) = 
    match contactMethod with 
    | PostalMail {HouseNumber=h;StreetName=s} -> printfn $"Mailing {message} to {h} {s}"
    | Email e -> printfn $"Emailing {message} to {e}"
    | VoiceMail {Code=c; Number=n} -> printfn $"Left +{c}{n} a voicemail saying {message}"

let message = "Can't talk now, learning F#!"

PostalMail {HouseNumber=1428; StreetName="Elm Street"}
|> sendMessage message

Email "suggestions@contoso.com"
|> sendMessage message

VoiceMail {Code=1;Number="5555555"}
|> sendMessage message

