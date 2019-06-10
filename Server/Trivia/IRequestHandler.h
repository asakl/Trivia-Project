#pragma once
#include "RequestStructures.h"

//to avoid circular definition problems.
struct RequestResult;
typedef struct Request Request;

class IRequestHandler
{
public:
	virtual bool isRequestRelevant(Request) = 0;
	virtual RequestResult handleRequest(Request) = 0;

};
