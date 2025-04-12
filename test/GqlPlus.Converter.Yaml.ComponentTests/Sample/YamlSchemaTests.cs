﻿using GqlPlus.Convert;

namespace GqlPlus.Sample;

public class YamlSchemaTests(
    ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Verify(result.ToYaml(string.IsNullOrWhiteSpace(section)), CustomSettings(label, "Yaml", test, section));
}
