//HintName: test_constraint-alt-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

public interface ItestCnstAltDualDual
  // No Base because it's Class
{
  ItestRefCnstAltDualDual<ItestAltCnstAltDualDual>? AsRefCnstAltDualDual { get; }
  ItestCnstAltDualDualObject? As_CnstAltDualDual { get; }
}

public interface ItestCnstAltDualDualObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltDualDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltDualDualObject<TRef>? As_RefCnstAltDualDual { get; }
}

public interface ItestRefCnstAltDualDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstAltDualDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstAltDualDualObject? As_PrntCnstAltDualDual { get; }
}

public interface ItestPrntCnstAltDualDualObject
  // No Base because it's Class
{
}

public interface ItestAltCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  ItestAltCnstAltDualDualObject? As_AltCnstAltDualDual { get; }
}

public interface ItestAltCnstAltDualDualObject
  : ItestPrntCnstAltDualDualObject
{
  decimal Alt { get; }
}
