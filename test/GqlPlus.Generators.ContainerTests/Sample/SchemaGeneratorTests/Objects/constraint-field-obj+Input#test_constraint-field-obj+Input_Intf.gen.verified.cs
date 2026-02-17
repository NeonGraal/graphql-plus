//HintName: test_constraint-field-obj+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp<ItestAltCnstFieldObjInp>
{
  ItestCnstFieldObjInpObject? As_CnstFieldObjInp { get; }
}

public interface ItestCnstFieldObjInpObject
  : ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>
{
}

public interface ItestRefCnstFieldObjInp<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldObjInpObject<TRef>? As_RefCnstFieldObjInp { get; }
}

public interface ItestRefCnstFieldObjInpObject<TRef>
  : IGqlpModelImplementationBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstFieldObjInpObject? As_PrntCnstFieldObjInp { get; }
}

public interface ItestPrntCnstFieldObjInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  ItestAltCnstFieldObjInpObject? As_AltCnstFieldObjInp { get; }
}

public interface ItestAltCnstFieldObjInpObject
  : ItestPrntCnstFieldObjInpObject
{
  decimal Alt { get; }
}
