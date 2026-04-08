//HintName: test_constraint-field-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

public interface ItestCnstFieldDualDual
  : ItestRefCnstFieldDualDual<ItestAltCnstFieldDualDual>
{
  ItestCnstFieldDualDualObject? As_CnstFieldDualDual { get; }
}

public interface ItestCnstFieldDualDualObject
  : ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>
{
}

public interface ItestRefCnstFieldDualDual<TRef>
  // No Base because it's Class
{
  ItestRefCnstFieldDualDualObject<TRef>? As_RefCnstFieldDualDual { get; }
}

public interface ItestRefCnstFieldDualDualObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstFieldDualDualObject? As_PrntCnstFieldDualDual { get; }
}

public interface ItestPrntCnstFieldDualDualObject
  // No Base because it's Class
{
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  ItestAltCnstFieldDualDualObject? As_AltCnstFieldDualDual { get; }
}

public interface ItestAltCnstFieldDualDualObject
  : ItestPrntCnstFieldDualDualObject
{
  decimal Alt { get; }
}
