using System;

"Up".ParseDirectionOrElse(s => throw new FormatException());
"Up".ParseDirectionOrDefault(Direction.Left).Next().Previous();