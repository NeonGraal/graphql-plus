//HintName: test_constraint-alt-obj+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public interface ItestCnstAltObjInp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltObjInp<ItestAltCnstAltObjInp>? AsRefCnstAltObjInp { get; }
  ItestCnstAltObjInpObject? As_CnstAltObjInp { get; }
}

public interface ItestCnstAltObjInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltObjInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltObjInpObject<TRef>? As_RefCnstAltObjInp { get; }
}

public interface ItestRefCnstAltObjInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltObjInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltObjInpObject? As_PrntCnstAltObjInp { get; }
}

public interface ItestPrntCnstAltObjInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  ItestAltCnstAltObjInpObject? As_AltCnstAltObjInp { get; }
}

public interface ItestAltCnstAltObjInpObject
  : ItestPrntCnstAltObjInpObject
{
  decimal Alt { get; }
}
