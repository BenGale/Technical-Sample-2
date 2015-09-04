# Technical Test

## Chest Request

I've implemented this chest in a way that any player that made a request to it
would get the same item if the configuration of the item drop weightings isn't 
changed. Every chest can be generated with a different identifier and this will
make sure that chests give out random items.

I took the chest identifier and the object identifier and concatenated them so
that a player wouldn't be able to approach the same chest multiple times and 
keep getting items from them, in the inventory or similar you'd be able to detect
the duplicates. The GetHashCode method should be unique enough for this usage.

At this point you could open a limitless amount of chests by generating Guids,
this obviously wouldn't work in the real word and it would need some sort of
check that the chest was generated on the map.

I'm not happy with passing the username through in this request, but I wanted to
meet the requirement for logging the specification. In a normal situation I would
expect to be able to get this information from some sort of authentication setup.
At this point I was right up againt my three hours though.

## In-Memory Configuration

To keep things simple for this test I've just implemented the configuration store
in a simple list, this is provided from Ninject as a singleton. With more time I 
could consider different persistence technologies depedning on the requirements
for scale and latency.

## Testing

I have followed TDD with this project. I was hoping with more time to take a look
at implementing some tests with SpecFlow after you mentioned Gherkin on the phone.
Alas, time was against me.

## Optomisation

I haven't done much in the way of optomisation, within the time limit I wasn't able
to get to the point of profiling to look at any pain points.
