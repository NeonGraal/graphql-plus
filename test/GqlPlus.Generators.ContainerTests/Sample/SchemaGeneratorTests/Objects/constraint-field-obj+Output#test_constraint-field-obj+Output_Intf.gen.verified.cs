//HintName: test_constraint-field-obj+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
{
  ItestCnstFieldObjOutpObject AsCnstFieldObjOutp { get; }
}

public interface ItestCnstFieldObjOutpObject
  : ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>
{
}

public interface ItestRefCnstFieldObjOutp<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldObjOutpObject<TRef> AsRefCnstFieldObjOutp { get; }
}

public interface ItestRefCnstFieldObjOutpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstFieldObjOutpObject AsPrntCnstFieldObjOutp { get; }
}

public interface ItestPrntCnstFieldObjOutpObject
{
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  ItestAltCnstFieldObjOutpObject AsAltCnstFieldObjOutp { get; }
}

public interface ItestAltCnstFieldObjOutpObject
  : ItestPrntCnstFieldObjOutpObject
{
  decimal Alt { get; }
}
