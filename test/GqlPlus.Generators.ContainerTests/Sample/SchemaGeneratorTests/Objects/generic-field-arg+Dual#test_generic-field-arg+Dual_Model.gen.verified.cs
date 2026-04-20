//HintName: test_generic-field-arg+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public class testGnrcFieldArgDual<TType>
  : GqlpModelBase
  , ItestGnrcFieldArgDual<TType>
{
  public ItestGnrcFieldArgDualObject<TType>? As_GnrcFieldArgDual { get; set; }
}

public class testGnrcFieldArgDualObject<TType>
  : GqlpModelBase
  , ItestGnrcFieldArgDualObject<TType>
{
  public ItestRefGnrcFieldArgDual<TType> Field { get; set; }

  public testGnrcFieldArgDualObject
    ( ItestRefGnrcFieldArgDual<TType> pfield
    )
  {
    Field = pfield;
  }
}

public class testRefGnrcFieldArgDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldArgDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldArgDualObject<TRef>? As_RefGnrcFieldArgDual { get; set; }
}

public class testRefGnrcFieldArgDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcFieldArgDualObject<TRef>
{

  public testRefGnrcFieldArgDualObject
    ()
  {
  }
}
