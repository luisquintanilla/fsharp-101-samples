module Domain =

    type Address =
        { HouseNumber: int
          StreetName: string }

    type PhoneNumber = { Code: int; Number: string }

    type ContactMethod =
        | PostalMail of Address
        | Email of string
        | VoiceMail of PhoneNumber
        | SMS of PhoneNumber

module Messenger =

    open Domain

    let sendMessage (message: string) (contactMethod: ContactMethod) =
        match contactMethod with
        | PostalMail { HouseNumber = h; StreetName = s } -> printfn $"Mailing {message} to {h} {s}"
        | Email e -> printfn $"Emailing {message} to {e}"
        | VoiceMail { Code = c; Number = n } -> printfn $"Left +{c}{n} a voicemail saying {message}"

(**MAIN APPLICATION**)

open Domain
open Messenger

let messages =
    [ "F# is good for the soul",
      (PostalMail
          { HouseNumber = 1428
            StreetName = "Elm Street" })
      "Learn F#, this is the way", Email "suggestions@contoso.com"
      "F# is succinct, performant, robust, and practical", VoiceMail { Code = 1; Number = "5555555" } ]

messages
|> List.iteri
    (fun i (message, contactMethod) ->
        printf $"{i}. "
        sendMessage message contactMethod)
