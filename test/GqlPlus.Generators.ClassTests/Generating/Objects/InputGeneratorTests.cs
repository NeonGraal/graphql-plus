﻿namespace GqlPlus.Generating.Objects;

public class InputGeneratorTests
  : TypeGeneratorClassTestBase<IGqlpInputObject, IGqlpObjBase>
{
  public override string ExpectedTypePrefix => "Input";
  internal override GenerateForType<IGqlpInputObject> TypeGenerator { get; }
    = new InputGenerator();
}
