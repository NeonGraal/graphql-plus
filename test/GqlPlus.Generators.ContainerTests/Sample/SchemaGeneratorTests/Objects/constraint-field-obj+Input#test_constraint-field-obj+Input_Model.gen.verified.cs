//HintName: test_constraint-field-obj+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public class testCnstFieldObjInp
  : testRefCnstFieldObjInp<ItestAltCnstFieldObjInp>
  , ItestCnstFieldObjInp
{
  public ItestCnstFieldObjInpObject? As_CnstFieldObjInp { get; set; }
}

public class testCnstFieldObjInpObject
  : testRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>
  , ItestCnstFieldObjInpObject
{

  public testCnstFieldObjInpObject
    ( ItestAltCnstFieldObjInp field
    ) : base(field)
  {
  }
}

public class testRefCnstFieldObjInp<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldObjInp<TRef>
{
  public ItestRefCnstFieldObjInpObject<TRef>? As_RefCnstFieldObjInp { get; set; }
}

public class testRefCnstFieldObjInpObject<TRef>
  : GqlpModelBase
  , ItestRefCnstFieldObjInpObject<TRef>
{
  public TRef Field { get; set; }

  public testRefCnstFieldObjInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}

public class testPrntCnstFieldObjInp
  : GqlpModelBase
  , ItestPrntCnstFieldObjInp
{
  public string? AsString { get; set; }
  public ItestPrntCnstFieldObjInpObject? As_PrntCnstFieldObjInp { get; set; }
}

public class testPrntCnstFieldObjInpObject
  : GqlpModelBase
  , ItestPrntCnstFieldObjInpObject
{

  public testPrntCnstFieldObjInpObject
    ()
  {
  }
}

public class testAltCnstFieldObjInp
  : testPrntCnstFieldObjInp
  , ItestAltCnstFieldObjInp
{
  public ItestAltCnstFieldObjInpObject? As_AltCnstFieldObjInp { get; set; }
}

public class testAltCnstFieldObjInpObject
  : testPrntCnstFieldObjInpObject
  , ItestAltCnstFieldObjInpObject
{
  public decimal Alt { get; set; }

  public testAltCnstFieldObjInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
