//HintName: test_constraint-alt-obj+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public interface ItestCnstAltObjInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltObjInp<ItestAltCnstAltObjInp>? AsRefCnstAltObjInp { get; }
  ItestCnstAltObjInpObject? As_CnstAltObjInp { get; }
}

public interface ItestCnstAltObjInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstAltObjInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefCnstAltObjInpObject<TRef>? As_RefCnstAltObjInp { get; }
}

public interface ItestRefCnstAltObjInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstAltObjInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstAltObjInpObject? As_PrntCnstAltObjInp { get; }
}

public interface ItestPrntCnstAltObjInpObject
  : IGqlpModelImplementationBase
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
