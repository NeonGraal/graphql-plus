﻿//HintName: Model_Intro_Output.gen.cs
// Generated from Intro_Output.graphql+
/*
output _TypeOutput {
    : _TypeObject<_TypeKind.Output _OutputParent _OutputField _OutputAlternate>
    }
output _OutputBase {
    : _ObjBase
        output: _Identifier
    | _DualBase
    }
output _OutputParent {
    : _ObjDescribed<_OutputBase>
    }
output _OutputField {
    : _Field<_OutputBase>
        parameter: _InputParam[]
    | _OutputEnum
    }
output _OutputAlternate {
    : _Alternate<_OutputBase>
    }
output _OutputArg {
    : _TypeRef<_TypeKind>
        member: _Identifier?
    | _TypeParam
    }
output _OutputEnum {
    : _TypeRef<_TypeKind.Enum>
        field: _Identifier
        member: _Identifier
    }
*/
namespace GqlPlus;
public class Model_Intro_Output {}