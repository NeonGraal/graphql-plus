//HintName: test_constraint-field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp<ItestAltCnstFieldDualInp>
{
  ItestCnstFieldDualInpObject? As_CnstFieldDualInp { get; }
}

public interface ItestCnstFieldDualInpObject
  : ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>
{
}

public interface ItestRefCnstFieldDualInp<TRef>
  // No Base because it's Class
{
  ItestRefCnstFieldDualInpObject<TRef>? As_RefCnstFieldDualInp { get; }
}

public interface ItestRefCnstFieldDualInpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstFieldDualInpObject? As_PrntCnstFieldDualInp { get; }
}

public interface ItestPrntCnstFieldDualInpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  ItestAltCnstFieldDualInpObject? As_AltCnstFieldDualInp { get; }
}

public interface ItestAltCnstFieldDualInpObject
  : ItestPrntCnstFieldDualInpObject
{
  decimal Alt { get; }
}
