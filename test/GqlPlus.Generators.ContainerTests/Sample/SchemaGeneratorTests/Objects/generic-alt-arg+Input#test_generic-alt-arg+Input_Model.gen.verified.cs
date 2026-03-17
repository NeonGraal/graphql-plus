//HintName: test_generic-alt-arg+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public class testGnrcAltArgInp<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgInp<TType>
{
  public ItestRefGnrcAltArgInp<TType>? AsRefGnrcAltArgInp { get; set; }
  public ItestGnrcAltArgInpObject<TType>? As_GnrcAltArgInp { get; set; }
}

public class testGnrcAltArgInpObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgInpObject<TType>
{
}

public class testRefGnrcAltArgInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgInpObject<TRef>? As_RefGnrcAltArgInp { get; set; }
}

public class testRefGnrcAltArgInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgInpObject<TRef>
{
}
