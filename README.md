So this is just a quick project I've wanted to do for a while. The original idea was to have a little dial I could use to scroll through debugging in Visual Studio or whatever IDE. Actually, the idea was inspired by the old "grind crank", a (semi-) mythical apparatus that you turn to make the computer do stuff faster.

Being a born over-engineer, natchally I decided to make it more general purpose, hence this project. It lets you set behaviors for turning a detented ("clicky") rotary encoder, clockwise or counter-clockwise, with or without the button being pressed. Then, when it receives input from the encoder, the program checks which program is currently active (read: in focus) and, if it has commands associated with it, passes them along.

Things to do yet:
* Make sure the code can send combo keys (alt-X, ctl-Y, etc)
* Make a full BOM

Incidentally, the grind crank has had at least one real-life instance: https://jargonfile.johnswitzerland.com/grind-crank.html
(the link referenced in the entry is dead btw, use this one: https://web.archive.org/web/20150101044158/http://www.cs.rice.edu/History/R1/ - it's quite the read.)
