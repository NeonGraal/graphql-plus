//HintName: test_constraint-field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public interface ItestCnstFieldDualOutp
  : ItestRefCnstFieldDualOutp<ItestAltCnstFieldDualOutp>
{
  ItestCnstFieldDualOutpObject? As_CnstFieldDualOutp { get; }
}

public interface ItestCnstFieldDualOutpObject
  : ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>
{
}

public interface ItestRefCnstFieldDualOutp<TRef>
  // No Base because it's Class
{
  ItestRefCnstFieldDualOutpObject<TRef>? As_RefCnstFieldDualOutp { get; }
}

public interface ItestRefCnstFieldDualOutpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstFieldDualOutpObject? As_PrntCnstFieldDualOutp { get; }
}

public interface ItestPrntCnstFieldDualOutpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  ItestAltCnstFieldDualOutpObject? As_AltCnstFieldDualOutp { get; }
}

public interface ItestAltCnstFieldDualOutpObject
  : ItestPrntCnstFieldDualOutpObject
{
  decimal Alt { get; }
}
