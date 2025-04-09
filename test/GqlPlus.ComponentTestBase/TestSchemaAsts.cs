﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public abstract class TestSchemaAsts(
    ISchemaParseChecks checks
) : TestSchemaInputs
{

  protected override async Task Label_Input(string label, string input, string[] dirs, string test, string section)
  {
    IGqlpSchema asts = checks.ParseInput(input, label);

    await Test_Asts([asts], test, label, dirs, section, input);
  }

  protected override async Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    IEnumerable<IGqlpSchema> asts = inputs.Select(input => checks.ParseInput(input, label));

    await Test_Asts(asts, test, label);
  }

  protected virtual Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[]? dirs = null)
    => Test_Asts(asts, test, label, dirs ?? [label], "");

  protected abstract Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string section, string input = "");
}
