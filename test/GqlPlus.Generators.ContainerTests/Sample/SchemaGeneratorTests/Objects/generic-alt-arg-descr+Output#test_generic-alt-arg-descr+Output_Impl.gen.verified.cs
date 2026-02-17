//HintName: test_generic-alt-arg-descr+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public class testGnrcAltArgDescrOutp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgDescrOutp<TType>
{
  public ItestRefGnrcAltArgDescrOutp<TType>? AsRefGnrcAltArgDescrOutp { get; set; }
  public ItestGnrcAltArgDescrOutpObject<TType>? As_GnrcAltArgDescrOutp { get; set; }
}

public class testGnrcAltArgDescrOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgDescrOutpObject<TType>
{

  public testGnrcAltArgDescrOutpObject()
  {
  }
}

public class testRefGnrcAltArgDescrOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgDescrOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDescrOutpObject<TRef>? As_RefGnrcAltArgDescrOutp { get; set; }
}

public class testRefGnrcAltArgDescrOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgDescrOutpObject<TRef>
{

  public testRefGnrcAltArgDescrOutpObject()
  {
  }
}
