//HintName: test_generic-field-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public interface ItestGnrcFieldDualDual
  // No Base because it's Class
{
  ItestGnrcFieldDualDualObject? As_GnrcFieldDualDual { get; }
}

public interface ItestGnrcFieldDualDualObject
  // No Base because it's Class
{
  ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; }
}

public interface ItestRefGnrcFieldDualDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualDualObject<TRef>? As_RefGnrcFieldDualDual { get; }
}

public interface ItestRefGnrcFieldDualDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcFieldDualDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcFieldDualDualObject? As_AltGnrcFieldDualDual { get; }
}

public interface ItestAltGnrcFieldDualDualObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
