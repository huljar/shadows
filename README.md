# Shadows

*shadows* is a .NET application written in C#. It allows the user to search
selected directories for duplicate files.

There are different levels of
accuracy which the user can select, with higher accuracy resulting in longer
search times. For example, one can compare files only by name and size, which
is very fast. However, identical file names and sizes do not necessarily mean
that the content of the files is the same as well. On the other hand, one can
choose to compare the whole contents of files, resulting in much longer search
times but making sure that the files are actually duplicates.

The search results are then displayed in a table for the user to inspect. From
here, one can directly delete files or view them in Windows Explorer. In addition,
some comfort functions are available to process large result tables quickly and
efficiently.

## License

The code is licensed under the terms of the GNU General Public License (GPL)
Version 3. For more information, please see the LICENSE.md file.
