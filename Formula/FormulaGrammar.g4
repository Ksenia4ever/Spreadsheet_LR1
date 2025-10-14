grammar FormulaGrammar;

compileUnit : expression EOF;

expression :
	LPAREN expression RPAREN #ParenthesizedExpr
	| INC LPAREN expression RPAREN #IncExpr
    | DEC LPAREN expression RPAREN #DecExpr
    | MAX LPAREN expression COMMA expression RPAREN #MaxExpr
    | MIN LPAREN expression COMMA expression RPAREN #MinExpr	
	| expression EXPONENT expression #ExponentialExpr
    | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
	| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
	| NUMBER #NumberExpr
	| IDENTIFIER #IdentifierExpr
	; 

/*
 * Lexer Rules
 */

NUMBER : INT (('.'|',') INT)?; 
IDENTIFIER : [a-zA-Z]+[1-9][0-9]*;

INT : ('0'..'9')+;

INC : 'inc' ;
DEC : 'dec' ;
MAX : 'max' ;
MIN : 'min' ;

EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';
COMMA  : ',' ;

WS : [ \t\r\n] -> channel(HIDDEN);
