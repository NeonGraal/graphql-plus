//HintName: test_constraint-field-domain+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

public class testCnstFieldDmnOutp
  : testRefCnstFieldDmnOutp<ItestDomCnstFieldDmnOutp>
  , ItestCnstFieldDmnOutp
{
  public ItestCnstFieldDmnOutpObject? As_CnstFieldDmnOutp { get; set; }
}

public class testCnstFieldDmnOutpObject
  : testRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>
  , ItestCnstFieldDmnOutpObject
{

  public testCnstFieldDmnOutpObject
    ( ItestDomCnstFieldDmnOutp pfield
    ) : base(pfield)
  {
  }
}

public class testRefCnstFieldDmnOutp<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDmnOutp<TRef>
{
  public ItestRefCnstFieldDmnOutpObject<TRef>? As_RefCnstFieldDmnOutp { get; set; }
}

public class testRefCnstFieldDmnOutpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldDmnOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDmnOutpObject
    ( TRef pfield
    )
  {
    Field = pfield;
  }
}

public class testDomCnstFieldDmnOutp
  : GqlpDomainString
  , ItestDomCnstFieldDmnOutp
{
}
