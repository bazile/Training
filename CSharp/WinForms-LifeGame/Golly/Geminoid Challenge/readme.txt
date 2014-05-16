via http://science.d3.ru/comments/559544/

--------------------------------

from http://conwaylife.com/forums/viewtopic.php?f=2&t=1006&start=133

All done now. I've attached three versions. In all of them, the child copy of the replicator is delayed 277 ticks compared to its parent. It would take a fairly comprehensive redesign to change this.

In all three versions, the memory loop period is a multiple of 277. So a descendant replicator will eventually match the original ancestor's phase, and this will happen as soon as possible -- but even in the smallest version, this won't be for several hundred thousand replication cycles (!)

The first version is Replicator-p237228340.mc.gz (27K):

Replicator-p237228340.mc.gz
    Fastest-running linear replicator	
    (26.59 KiB) Downloaded 1289 times


This has a fairly ridiculous bounding box -- 14826990x14826908 -- and needs the largest number of ticks to complete a replication cycle. But in Golly it runs much faster than the other versions. The construction information is carried by the first two gliders in each set of four in the memory loop. The last two gliders have no timing constraints; their only purpose is to reset the constructor-arm circuit.

It turns out, not surprisingly, that Golly has a lot of trouble with tightly-packed streams of gliders traveling close to each other in opposite directions. But the gliders in this replicator's oversized memory loop spend a fair amount of time mostly traveling in the same direction. Golly runs fastest when all the gliders are stretched out in a single line heading NW or SE.

The population starts out at 290096 ON cells, almost all gliders. After one cycle of 237228340 ticks, the replicator will return to its original state, and a second copy will have been created directly to the north, offset by (0,-256). The only difference between parent and child is the 277-tick delay -- so for the first four replication cycles the population will be an exact multiple of its original value.

The second version is Replicator-p118614724.mc.gz (52K):

Replicator-p118614724.mc.gz
    Slower but smaller replicator version	
    (51.66 KiB) Downloaded 229 times


The bounding box is reduced by half by doubling over the glider stream on itself... but this means that gliders are constantly passing each other at close range, so the number of hashlife tiles goes up exponentially and the pattern runs slower in Golly -- even though the replication cycle completes in half the number of ticks.

In the third version, Replicator-p88965198.mc.gz (64K), the non-coding gliders have been removed, so the first half of the recipe is interleaved with the second half. The bounding box goes down to 3707102x3707020, marginally smaller than a Geminoid spaceship, but the gliders now need three trips around the memory loop to complete a replication cycle -- two passes for the BUILD stage and one more pass for the COPY stage.

Replicator-p88965198.mc.gz
    Smallest and slowest replicator version	
    (63.83 KiB) Downloaded 312 times

