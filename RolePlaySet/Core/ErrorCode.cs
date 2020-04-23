using System;

namespace RolePlaySet.Core
{
    public enum ErrorCode
    {
        None = 0,
        NotCategorisedError=1,
        BasicSystemError = 2,
        InvalidTaskType = 4,
        NotSupportedDiceType = 8,
        GameNameIsNotValid = 16,
        GameIsNotFound = 32,
        CouldNotCreateNewGame = 64
    }
    /* 
     sum error with binary operation
            None      = 0b_0000_0000,  // 0
            Monday    = 0b_0000_0001,  // 1
            Tuesday   = 0b_0000_0010,  // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday  = 0b_0000_1000,  // 8
            Friday    = 0b_0001_0000,  // 16
            Saturday  = 0b_0010_0000,  // 32
            Sunday    = 0b_0100_0000,  // 64
      */
}
