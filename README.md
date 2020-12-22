# EvergreenLifeParser

A very simple parser for parsing files exported from the [Evergreen Life](https://www.evergreen-life.co.uk/) app, for manipulation or importation into other platforms. 

## XML Format 

The XML format used is not documented anywhere, for results (the focus so far) it does not seem to be in an easy format that can just be de-serialized. Namely, inside some some of the `result` elements are repeated where they should really be their own `result`(e.g a full blood count result is made up of a number of different results). This requires logic to parse, which could be improved. 

Hopefully parsing the other outputs from Evergreen will be easy as they seem to be a bit more standard. 

## Implementation
- [x] Results
- [ ] Summary
- [ ] Consultations
- [ ] Medication
- [ ] Immunisations
