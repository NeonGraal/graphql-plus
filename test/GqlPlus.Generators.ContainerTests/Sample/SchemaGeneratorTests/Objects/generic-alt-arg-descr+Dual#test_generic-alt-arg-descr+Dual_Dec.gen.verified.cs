//HintName: test_generic-alt-arg-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public interface ItestGnrcAltArgDescrDual<TType>
  // No Base because it's Class
{
  ItestRefGnrcAltArgDescrDual<TType>? AsRefGnrcAltArgDescrDual { get; }
  ItestGnrcAltArgDescrDualObject<TType>? As_GnrcAltArgDescrDual { get; }
}

public interface ItestGnrcAltArgDescrDualObject<TType>
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltArgDescrDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrDualObject<TRef>? As_RefGnrcAltArgDescrDual { get; }
}

public interface ItestRefGnrcAltArgDescrDualObject<TRef>
  // No Base because it's Class
{
}
