//HintName: test_constraint-alt-obj+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public interface ItestCnstAltObjOutp
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp> AsRefCnstAltObjOutp { get; }
  ItestCnstAltObjOutpObject AsCnstAltObjOutp { get; }
}

public interface ItestCnstAltObjOutpObject
{
}

public interface ItestRefCnstAltObjOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefCnstAltObjOutpObject<TRef> AsRefCnstAltObjOutp { get; }
}

public interface ItestRefCnstAltObjOutpObject<TRef>
{
}

public interface ItestPrntCnstAltObjOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstAltObjOutpObject AsPrntCnstAltObjOutp { get; }
}

public interface ItestPrntCnstAltObjOutpObject
{
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  ItestAltCnstAltObjOutpObject AsAltCnstAltObjOutp { get; }
}

public interface ItestAltCnstAltObjOutpObject
  : ItestPrntCnstAltObjOutpObject
{
  decimal Alt { get; }
}
