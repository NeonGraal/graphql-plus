//HintName: test_generic-field-arg+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public class testGnrcFieldArgDual<TType>
  : GqlpModelImplementationBase
  , ItestGnrcFieldArgDual<TType>
{
  public ItestGnrcFieldArgDualObject<TType>? As_GnrcFieldArgDual { get; set; }
}

public class testGnrcFieldArgDualObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcFieldArgDualObject<TType>
{
  public ItestRefGnrcFieldArgDual<TType> Field { get; set; }

  public testGnrcFieldArgDualObject
    ( ItestRefGnrcFieldArgDual<TType> field
    )
  {
    Field = field;
  }
}

public class testRefGnrcFieldArgDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcFieldArgDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcFieldArgDualObject<TRef>? As_RefGnrcFieldArgDual { get; set; }
}

public class testRefGnrcFieldArgDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcFieldArgDualObject<TRef>
{
}
