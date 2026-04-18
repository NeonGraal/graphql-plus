//HintName: test_constraint-field-obj+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public class testCnstFieldObjOutp
  : testRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
  , ItestCnstFieldObjOutp
{
  public ItestCnstFieldObjOutpObject? As_CnstFieldObjOutp { get; set; }
}

public class testCnstFieldObjOutpObject
  : testRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>
  , ItestCnstFieldObjOutpObject
{

  public testCnstFieldObjOutpObject
    ( ItestAltCnstFieldObjOutp field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldObjOutp<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldObjOutp<TRef>
{
  public ItestRefCnstFieldObjOutpObject<TRef>? As_RefCnstFieldObjOutp { get; set; }
}

public class testRefCnstFieldObjOutpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldObjOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldObjOutpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testPrntCnstFieldObjOutp
  : GqlpModelBase
  , ItestPrntCnstFieldObjOutp
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldObjOutpObject? As_PrntCnstFieldObjOutp { get; set; }
}

public class testPrntCnstFieldObjOutpObject
  : GqlpModelBase
  , ItestPrntCnstFieldObjOutpObject
{

  public testPrntCnstFieldObjOutpObject
    ()
  {
  }
}

public class testAltCnstFieldObjOutp
  : testPrntCnstFieldObjOutp
  , ItestAltCnstFieldObjOutp
{
  public ItestAltCnstFieldObjOutpObject? As_AltCnstFieldObjOutp { get; set; }
}

public class testAltCnstFieldObjOutpObject
  : testPrntCnstFieldObjOutpObject
  , ItestAltCnstFieldObjOutpObject
{
  public decimal Alt { get; set; }

  public testAltCnstFieldObjOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
