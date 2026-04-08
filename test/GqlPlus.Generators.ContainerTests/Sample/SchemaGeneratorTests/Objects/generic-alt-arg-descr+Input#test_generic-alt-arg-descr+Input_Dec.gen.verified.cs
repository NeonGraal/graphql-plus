//HintName: test_generic-alt-arg-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public interface ItestGnrcAltArgDescrInp<TType>
  // No Base because it's Class
{
  ItestRefGnrcAltArgDescrInp<TType>? AsRefGnrcAltArgDescrInp { get; }
  ItestGnrcAltArgDescrInpObject<TType>? As_GnrcAltArgDescrInp { get; }
}

public interface ItestGnrcAltArgDescrInpObject<TType>
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltArgDescrInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrInpObject<TRef>? As_RefGnrcAltArgDescrInp { get; }
}

public interface ItestRefGnrcAltArgDescrInpObject<TRef>
  // No Base because it's Class
{
}
