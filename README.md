# WhatTheCommit

A dotnet tool to get a commit messge from [whatthecommit.com](http://whatthecommit.com) on the commandline.

I aliased the command `dotnet {yourpathtoutput}/WhatTheCommit.dll` as `whatthecommit`, now I can commit my staged files in `git` with a funny commit message:

```bash
git commit -m "$(whatthecommit)"
```

## Warning

Only use this for your "Initial commit" and use proper commit messages all the other times ;)

