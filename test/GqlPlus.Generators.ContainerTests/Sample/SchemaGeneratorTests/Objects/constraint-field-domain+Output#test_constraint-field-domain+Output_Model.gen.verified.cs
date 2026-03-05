//HintName: test_constraint-field-domain+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
    ( ItestDomCnstFieldDmnOutp field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldDmnOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstFieldDmnOutp<TRef>
{
  public ItestRefCnstFieldDmnOutpObject<TRef>? As_RefCnstFieldDmnOutp { get; set; }
}

public class testRefCnstFieldDmnOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefCnstFieldDmnOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldDmnOutpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testDomCnstFieldDmnOutp
  : GqlpDomainString
  , ItestDomCnstFieldDmnOutp
{
}
