//HintName: test_constraint-alt-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public interface ItestCnstAltDualInp
  // No Base because it's Class
{
  ItestRefCnstAltDualInp<ItestAltCnstAltDualInp>? AsRefCnstAltDualInp { get; }
  ItestCnstAltDualInpObject? As_CnstAltDualInp { get; }
}

public interface ItestCnstAltDualInpObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltDualInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltDualInpObject<TRef>? As_RefCnstAltDualInp { get; }
}

public interface ItestRefCnstAltDualInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstAltDualInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstAltDualInpObject? As_PrntCnstAltDualInp { get; }
}

public interface ItestPrntCnstAltDualInpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  ItestAltCnstAltDualInpObject? As_AltCnstAltDualInp { get; }
}

public interface ItestAltCnstAltDualInpObject
  : ItestPrntCnstAltDualInpObject
{
  decimal Alt { get; }
}
