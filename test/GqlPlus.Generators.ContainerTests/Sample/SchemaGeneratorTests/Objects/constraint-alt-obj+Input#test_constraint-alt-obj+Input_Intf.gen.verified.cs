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
  ItestRefCnstAltObjInp<ItestAltCnstAltObjInp> AsRefCnstAltObjInp { get; }
  ItestCnstAltObjInpObject AsCnstAltObjInp { get; }
}

public interface ItestCnstAltObjInpObject
{
}

public interface ItestRefCnstAltObjInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefCnstAltObjInpObject<TRef> AsRefCnstAltObjInp { get; }
}

public interface ItestRefCnstAltObjInpObject<TRef>
{
}

public interface ItestPrntCnstAltObjInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstAltObjInpObject AsPrntCnstAltObjInp { get; }
}

public interface ItestPrntCnstAltObjInpObject
{
}

public interface ItestAltCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  ItestAltCnstAltObjInpObject AsAltCnstAltObjInp { get; }
}

public interface ItestAltCnstAltObjInpObject
  : ItestPrntCnstAltObjInpObject
{
  decimal Alt { get; }
}
